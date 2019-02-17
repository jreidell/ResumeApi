import React, { Component } from 'react';
import moment from 'moment';

export class ResView extends Component {
    displayName = ResView.name

    constructor(props) {
        super(props);
        this.state = { careerInfos: [], loading: true };

        //MICROSERVICE URL
        //https://localhost:44389/api/v1/CareerInfo/21a61a6a-6554-4e7f-a974-08d663d5d19f
        //https://localhost:8304/api/v1/CareerInfo/21a61a6a-6554-4e7f-a974-08d663d5d19f

        fetch('https://rdlsvc.azurewebsites.net/api/v1/CareerInfo/58f21038-a7e4-46ec-b036-08d667882bcb', {
            headers: {
                "Authorization": "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IlFURTROREU0UXpCR01UbENRekkyT1VZNFJUWkdRelF3UXpFME9FTXlRalpGTVVNNE9EVTFRdyJ9.eyJpc3MiOiJodHRwczovL3JkbG5ldHRlc3RhMC5hdXRoMC5jb20vIiwic3ViIjoiN3M4dEVkVERpOTNkeGg3dTB5eTZuNzhQaGQ0RzRaYTRAY2xpZW50cyIsImF1ZCI6Imh0dHBzOi8vcmRsbmV0dGVzdGEwLmF1dGgwLmNvbS9hcGkvdjIvIiwiaWF0IjoxNTQ3MDY3MzgzLCJleHAiOjE1NDcxNTM3ODMsImF6cCI6IjdzOHRFZFREaTkzZHhoN3UweXk2bjc4UGhkNEc0WmE0IiwiZ3R5IjoiY2xpZW50LWNyZWRlbnRpYWxzIn0.b65zpZ_miftTEp4h_Hx4fBO2JbRu7V_YsLS0fWm1sZL-BEJI3ro1-cF1Kf3C3D572ziVeh3zYXla3iiXk1j5dWr-ZLRrrQK3P20On6H7UOROgtPnG2Xw3LtMUv6PkNNDYH-_di1v5kBfwg02ndpVF2c1fAXUtIcmi8dc2qZDv8Cpm2tpDXGnIqf54zJYIpTOfGRvFfivPARW6Hpr8_3aBZCHIheiIOgBGkdyPi4no0cmz3ezWHbOht_ADUCTDZJps5ML9IIi0jLef0gctBmv4ClfUfeyKDGQAZLe0Efdm2ymGCY8GQD3a1viGB3f2n9QN3h3cvZAsFgHrqNtdh-NQA",
                }
            })
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
                                    <ul className="jobTitleSpacer" key={workHistory.WorkHistoryId}>
                                        <li className="empListing">{workHistory.Employer}, {moment(workHistory.StartDate).format("MMM YYYY")} - {moment(workHistory.EndDate).format("MMM YYYY")}</li>
                                        <li className="jobTitle">{workHistory.JobTitle}</li>
                                        <li className="jobDescription">{workHistory.JobDescription}</li>
                                        <li className="noDotLi">
                                            <ul className="jobDetailSpacer">
                                                {workHistory.WorkHistoryDetails.map(workHistoryDetail =>
                                                    <li key={workHistoryDetail.WorkHistoryDetailId} className="workHistoryDetail">{workHistoryDetail.ContentBody}</li>
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