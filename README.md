# Store Application Web API - Revature



[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
## Description

The purpose of this app was to meet the requirements of the following user story:


As a Store Owner

I want to have a web API 

So that I can have a web-based application that easily manages and has functionality for my store
 
As such, this application is a store management application built with with ASP.NET, a framework of dotnet and currently has a monolithic architecture. 


## Table of Contents 
* [License](#license)
* [Technologies](#technologies)
* [Getting Started](#getting)
* [Usage](#usage)
* [Questions](#questions)
* [Links](#links)
    
## License
This project is licensed under the mit license.

## Technologies
C#  
ADO.NET  
Xunit  
Moq  
Serilog  
Azure  
Azure DevOps  
ASP.NET webapi  

    
## Features

<strong>Add a new customer</strong>  
{api endpoint later}

<strong>Search for a customer</strong>  
{api endpoint later}

<strong>Display details of an order for a specific customer or an order id</strong>  
{api endpoint later}


<strong>Place orders to store locations for customers which can include multiple products</strong>  
{api endpoint later}


<strong>View order history of customer</strong>  
{api endpoint later}


<strong>Orders can be sorted by newest/oldest/highest total price/lowest total price</strong>  
{api endpoint later}


<strong>View a location's inventory(Checks to ensure user is admin first)</strong>  
{api endpoint later}


<strong>Able to replenish inventory(Checks to ensure user is admin first)</strong>  
{api endpoint later}


## Getting Started

Instructions on installing this project locally:

(WIP)

Clone repo locally from the github repository.(Commands and steps later)  

## Usage  

Make sure current directory is in the ProjAPI directory folder and run the cli command  
```dotnet run```  

Can test endpoints by opening whatever localhost:XXXX project is being listened to on with a further endpoint of /swagger/index.html in the browser, it should look like:  
```http://localhost:{yourportnumber}/swagger/index.html```  

Can run unit tests by ensuring you are in the ProjTest directory folder and run the cli command  
```dotnet test```


## Questions
To contact me or report issues, please email me at jonathon.renaud@revature.net
   

## Links
[Azure Deployment "customer/getall" Test](https://projdemo.azurewebsites.net/api/Store/customer/getall)  
[LinkedIn](https://www.linkedin.com/in/jonathon-renaud-410910aa/)

Base Azure Deployed App Link:  
```https://projdemo.azurewebsites.net/{api calls go here}```
