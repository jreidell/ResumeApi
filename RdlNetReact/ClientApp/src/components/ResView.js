import React, { Component } from 'react';
import moment from 'moment';

export class ResView extends Component {
    displayName = ResView.name

    constructor(props) {
        super(props);
        this.state = { careerInfos: [], loading: true };

        //MICROSERVICE URL
        //https://localhost:8304/api/v1/CareerInfo?id=21a61a6a-6554-4e7f-a974-08d663d5d19f
        //https://rdlsvc.azurewebsites.net/api/v1/CareerInfo?id=58f21038-a7e4-46ec-b036-08d667882bcb

        fetch('https://localhost:8304/api/v1/CareerInfo?id=21a61a6a-6554-4e7f-a974-08d663d5d19f')
            .then(response => response.json())
            .then(data => {
                this.setState({ careerInfos: data, loading: false });
            });
    }

    static renderResumeDiv(careerInfos) {
        return (
            <table className='table'>
                <tbody>
                    {careerInfos.map(careerInfo =>
                        <tr key={careerInfo.CareerInfoId}>
                            <td>
                                <h2>{careerInfo.FirstName} {careerInfo.MiddleName} {careerInfo.LastName}, {careerInfo.Suffix}</h2>
                                <h6>{careerInfo.Address1}, {careerInfo.City}, {careerInfo.State} {careerInfo.PostalCode}</h6>
                                <h6>{careerInfo.EmailAddress}, {careerInfo.Phone}, Mobile: {careerInfo.Mobile}, </h6>
                                <hr />
                                <h4>{careerInfo.CareerInfoTitle}</h4>
                                <hr />
                                <p>{careerInfo.Summary}</p>
                                <hr />
                                <ul id="limheight">
                                    {careerInfo.JobSkills.map(jobSkill =>
                                        <li key={jobSkill.JobSkillId}>{jobSkill.JobSkillTitle}</li>
                                    )}
                                </ul>
                                <hr />
                                    {careerInfo.WorkHistory.map(workHistory =>
                                    <ul key={workHistory.WorkHistoryId} id="jobTitleSpacer">
                                        <li class="empListing">{workHistory.Employer}, {moment(workHistory.StartDate).format("MMM YYYY")} - {moment(workHistory.EndDate).format("MMM YYYY")}</li>
                                        <li class="jobTitle">{workHistory.JobTitle}</li>
                                        <li class="jobDescription">{workHistory.JobDescription}</li>
                                        <li class="noDotLi">
                                            <ul id="jobDetailSpacer">
                                                {workHistory.WorkHistoryDetails.map(workHistoryDetail =>
                                                    <li class="workHistoryDetail" key={workHistoryDetail.WorkHistoryDetailId}>{workHistoryDetail.ContentBody}</li>
                                                )}
                                            </ul>
                                        </li>
                                        <hr />
                                    </ul>
                                    )}
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading Web API Data...</em></p>
            : ResView.renderResumeDiv(this.state.careerInfos);

        return (
            <div>
                <h1>Resume Viewer</h1>
                <p>This component demonstrates viewing the resume data via React.</p>
                {contents}
            </div>
        );
    }
}