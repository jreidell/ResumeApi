import React, { Component } from 'react';
import moment from 'moment';
import { Layout } from './Layout';
import './ResPrint.css';

export class ResView extends Component {
    displayName = ResView.name

    constructor(props) {
        super(props);
        this.state = { careerInfos: [], loading: true, token: '' };

        //MICROSERVICE URL
        //https://localhost:44389/api/v1/CareerInfo/21a61a6a-6554-4e7f-a974-08d663d5d19f
        //https://localhost:8304/api/v1/CareerInfo/21a61a6a-6554-4e7f-a974-08d663d5d19f
        this.getTokenFromServer();
        fetch('https://rdlsvc.azurewebsites.net/api/v1/CareerInfo/58f21038-a7e4-46ec-b036-08d667882bcb', {
            headers: {
                "Authorization": `Bearer ${this.getToken()}`,
                }
            })
            .then(response => response.json())
            .then(data => {
                console.log(data);
                this.setState({ careerInfos: data, loading: false });
            });
    }

    getTokenFromServer() {
        // Get a token from api server using the fetch api
        return fetch('https://rdlsvc.azurewebsites.net/api/v1/AuthUser/GetToken')
            .then(response => response.json())
            .then(data => {
                console.log(data);
                console.log(data.access_token);
                this.setState({ token: data });
                this.setToken(this.state.token.access_token);
                //return Promise.resolve(res);
            });
    }

    setToken(idToken) {
        // Saves user token to localStorage
        localStorage.setItem('id_token', idToken);
    }

    getToken() {
        // Retrieves the user token from localStorage
        return localStorage.getItem('id_token');
    }

    static renderResumeDiv(careerInfos) {
        return (
            <div id="resumeContent">
                <div id="para">
                    <h2>{careerInfos.FirstName} {careerInfos.MiddleName} {careerInfos.LastName}, {careerInfos.Suffix}</h2>
                    <h6>{careerInfos.Address1}, {careerInfos.City}, {careerInfos.State} {careerInfos.PostalCode}</h6>
                    <h6>{careerInfos.EmailAddress}, {careerInfos.Phone}, Mobile: {careerInfos.Mobile}</h6>
                    <hr />
                    <h4>{careerInfos.CareerInfoTitle}</h4>
                    <hr />
                    <p>{careerInfos.Summary}</p>
                </div>
                <div id="detail">
                    <ul id="limheight">
                        {careerInfos.JobSkills.map(jobSkill =>
                            <li key={jobSkill.JobSkillId}>{jobSkill.JobSkillTitle}</li>
                        )}
                    </ul>
                    <hr />
                    {careerInfos.WorkHistory.map(workHistory =>
                        <ul key={workHistory.WorkHistoryId}>
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
                </div>
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading Web API Data...</em></p>
            : ResView.renderResumeDiv(this.state.careerInfos);

        return (
            <Layout>
               <div>
                  {contents}
                </div>
            </Layout>
        );
    }

}