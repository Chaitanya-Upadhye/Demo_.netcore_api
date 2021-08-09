

# Demo JWT Auth API .netcore 3.1

To develop and run ASP.NET Core applications locally, download and install the following:

.NET Core SDK - includes the .NET Core runtime and command line tools

C# extension for Visual Studio Code - adds support to VS Code for developing .NET Core applications



## Run Locally

Clone the project

```bash
  https://github.com/Chaitanya-Upadhye/Demo_.netcore_api.git
```


Start the server

```bash
  dotnet run
```


# How to authenticate a user with Postman

To authenticate a user with the api and get a JWT token follow these steps:

Open a new request tab by clicking the plus (+) button at the end of the tabs.

Change the http request method to "POST" with the dropdown selector on the left of the URL input field.
In the URL field enter the address to the authenticate route of your local API - https://localhost:44316/users/authenticate.
Select the "Body" tab below the URL field, change the body type radio button to "raw", and change the format dropdown selector to "JSON (application/json)".

Enter a JSON object containing the test username and password in the "Body" textarea:

```bash
{
    "username": "test",
    "password": "test"
    
}
```

Click the "Send" button, you should receive a "200 OK" response with the
 user details including a JWT token in the response body.




  
