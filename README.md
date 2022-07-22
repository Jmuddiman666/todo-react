 ## TODO App

 [![Azure Static Web Apps CI/CD](https://github.com/Jmuddiman666/todo-react/actions/workflows/azure-static-web-apps-ashy-sky-098133f03.yml/badge.svg?branch=main)](https://github.com/Jmuddiman666/todo-react/actions/workflows/azure-static-web-apps-ashy-sky-098133f03.yml)
 [![Build and deploy ASP.Net Core app to Azure Web App - jm-todo-sample](https://github.com/Jmuddiman666/todo-react/actions/workflows/actions-todo-api.yml/badge.svg?branch=main)](https://github.com/Jmuddiman666/todo-react/actions/workflows/actions-todo-api.yml)

 This is a fairly simple Todo App leveraging React (Typescript) and ASP.NET 6 WebApi
 This solution has taken 5-6 hours to put together, a lot of that effort has been getting the esproj project to communicate with the API, and styling. 
 
 ## Getting Started
 How do you build and run the solution?

 ### Visual Studio 
 Load Todo.sln
 Set startup projects to Todo.Api and Todo.Web
 Start (F5) or start without debugging (Ctrl + F5)

 ### CLI
 #### Todo.API 
 Navigate to Todo API, restore packages if needed and run with `dotnet run`
 ``` bash
 cd src/Todo.Api
 dotnet restore
 dotnet build -c Debug
 dotnet run
 ```


 #### Todo.Web

 Navigate to Todo.Web, restore packages if needed and run with `npm start`
 ``` bash
  cd src/todo.web 
  npm install 
  SET_SSL=true&&npm start
 ```


 ## Testing
 Unit tests have been written with XUnit `Todo.Api.UnitTests` and react-testing-library/jest `todo.web`
 ### CLI
 #### Todo.API
 Navigate to Todo Api Unit tests and run with `dotnet test`
 ``` bash
 cd src/todo.api.unittests
 dotnet test
 ```

  **NB: Tests relying on local files may be flakey**

 #### Todo.Web
 Navigate to Todo.Web and run with `npm test`

  ``` bash
  cd src/todo.web 
  npm install
  npm test
 ```

 ## Deployment
 Github actions automate the deployment of both the web and api. 

 Action workflows can be found in `.github/workflows`

 Web is hosted on Azure Static Apps
 https://ashy-sky-098133f03.1.azurestaticapps.net/

 API is hosted on Azure App Service
 http://jm-todo-sample.azurewebsites.net/

 ## Notes
 - What technical and functional assumptions did you make when implementing your solution? 
    - I made the assumtion the api would have access to the local file-system to write the test data; however, in a production environment the preferred repository would be a nosql database. 
    - I assumed the scale of this application would not warrant an optimized approach writing to the text file, nor a need to handle concurrent usage.
    - I made the functional assumption that the user would not have accessibility needs, the UX has not been optimized in any way.
    - I made the assumption testing needed to be done only for the happy path in this scenario.
 - Briefly explain your technical design and why do you think is the best approach to this problem.
    - The Front end application is composed of multiple functional components. 
    - The Todo App itself is a functional component that manages state using `useReducer`, passing a `dispatch` function down to its children.
    - The REST Client is comprised of an interface `IEndpointClient` and an implementing class `EndpointApiClient`, allowing flexibiity to swap out the implementation. e.g with a GraphQL Client.
    - The WebAPI uses the repository pattern and applies SOLID principles to ensure flexibility of interface implementations and single responsibility, relying heavily on Dependency injection.
    - The structure allows ease of unit testing by focusing on individual concrete implementations and mocking dependent services. 
 - If you were unable to complete any user stories, outline why and how would you have liked to implement them.
    - While all stories have been completed I would have preferred to implement a more robust data store than a text file, a Postgres database was considered but not implemented due to time constraints.
    - The UI is currently lacking, while functional it is otherwise unusable, more time is needed to produce an adequate front-end. 



