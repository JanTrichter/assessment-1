# Assessment
This is the assessment from Jan Richter.
The assessment uses Svelte as frontend framework  and .Net 6 for the backend. 
You will find Instructions for setting up the project here.

## Setup
### Backend

To start the .Net api you need to have [.Net 6 installed](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
> It is recommended to simply open the .sln file with Visual Studio / Jetbrains Rider and run the application from the IDE.

You can also start the application with the command line. 
1. (From the project root) navigate into the `api/api` folder.
2. Execute `dotnet run`.
3. The application now runs on `https://localhost:7120`.
4. Navigate to `https://localhost:7120/swagger` to see the Swagger api documentation.

This is all the setup needed for the backend. Next we start the frontend.

### Frontend
To run the frontend application, you need to have [Node.js](https://nodejs.org/en/download/) installed.

1. Move in the `app` folder
2. Run `npm install`
3. Run `npm run dev`
4. The application should now run on `localhost:8080`
