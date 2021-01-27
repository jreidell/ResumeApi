import React, { Component } from 'react';
import { Layout } from './Layout';

export class Home extends Component {
  displayName = Home.name

  render() {
    return (
      <Layout>
      <div>
        <h1>Reidell.Net - ASP.NET Core, Web API, REST, LINQ, AzureSQL (MSSQL), REACT, Angular, Bootstrap, JSON, Azure App Services, Xamarin, Android</h1>
        <p><strong>Welcome to my demo, single-page application, built with:</strong></p>
        <ul>
          <li><a href='https://azure.microsoft.com/en-us/'>Microsoft Azure</a> cloud, using Azure Application Services</li>
          <li>A REST API built on <a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
          <li><a href="https://azure.microsoft.com/en-us/services/sql-database/">Microsoft Azure SQL Server</a> for Data Storage</li>
          <li>One of the UIs is built with <a href='https://facebook.github.io/react/'>React</a> for client-side code</li>
          <li>One of the UIs is built with <a href='https://angular.io/'>Angular v5.x</a> and <a href='http://www.typescriptlang.org/'>TypeScript</a> for client-side code</li>
          <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
          <li>Review the Source Code for this application via my public <a href='https://github.com/jreidell/ResumeApi'>GitHub Repository</a></li>
        </ul>
            <p><strong>Some technologies that are showcased within this application are:</strong></p>
        <ul>
          <li><strong>Client-side navigation</strong>. For example, click <em>Reume Viewer</em> then <em>Back</em> to return here.</li>
          <li>An implementation of an Asynchronous <strong>Repository Pattern</strong> to add a layer of abstraction</li>
          <li>An implementation of the <strong>Unit of Work</strong> Pattern</li>
          <li>IoC or Inversion of Control is implemented by way of <strong>Dependency Injection</strong></li>
          <li>A <strong>RESTful Web API</strong> is used to expose the <strong>Microsoft AzureSQL</strong> data as <strong>JSON</strong> Entities</li>
          <li>I have also added a set of <strong>Xamarin, Cross-Platform, Mobile</strong> User Interface Applications to the <a href='https://github.com/jreidell/ResumeApi'>GitHub Repository</a></li>
          <li>I will soon be publishing an <strong>Android Application</strong> to the <strong>Google Play Store</strong></li>
        </ul>
        <p>Click the Resume Viewer link in the Navigation Menu to view realtime resume data from a cloud-based MSSQL Server Instance via an ASP.NET Core, Web API. UI Application is built on Angular version 5. This application is a real world representation of my actual resume in object form.</p>
      </div>
      </Layout>
    );
  }
}
