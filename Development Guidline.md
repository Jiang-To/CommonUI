# Development Guideline
This is the short guideline to get started quickly

# Integrated Development Mode
Under integrated mode, you can only simply press `F5` to get started. VS code shall build server-side code and serve it under a backend process with config placed in `launchSettings.json` has property `"commandName": "Project"`.   
* file location of `launchSettings.json`
  >  CommonUI.Server  
    &nbsp;&nbsp;&nbsp;&nbsp; \| -- Properties  
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; \| -- launchSettings.json
* debug config (may vary with versions)
    ```javascript
    "CommonUI.Server": {  
      "commandName": "Project",
      "launchBrowser": true,  
      "launchUrl": "api/values",  
      "applicationUrl": "https://localhost:5001;http://localhost:5000",  
      "environmentVariables": {  
        "ASPNETCORE_ENVIRONMENT": "Development"  // <- build-in values:  Development, Stage, Production (default: when no specify value for ASPNETCORE_ENVIRONMENT)
      }  
    } 
    ``` 

At the same time, VS code will boot up a webpack dev server for client-side. Code changes on client-side will almost real-time shows on the page http://localhost:5000 which called [Hot Module Replacement](https://webpack.js.org/concepts/hot-module-replacement). 
The underlying mechanism is when server-side starting up, it runs script `npm run serve` under client-side root folder triggered by below code snippet placed in `Startup.cs`.  

* when sever runs under development environment
    ```csharp
    app.UseSpa(spa => {
        spa.Options.SourcePath = @"..\CommonUI.Client";
        spa.UseVueCli(npmScript: "serve", port: 8080);
    });
    ```

# Separate Development Mode 
under this mode, you need to start up client-side dev server manually by command line or Vue UI. The way of Sever-side startup remains no change(Press `F5` in VS code).
* Using Command line  
start command line at `CommonUI.Client` and run `npm run serve`
    
    - command line output  
      <img src="https://i.imgur.com/9XMaYfQ.png" width="450">
      
* Using Vue UI  
make sure you have install [Vue cli](https://cli.vuejs.org/guide/installation.html) , 
start command line at `CommonUI.Client` and run `vue ui`

    - command line output  
      <img src="https://i.imgur.com/brTjrBw.png" width="250">
    - visit Vue Project Manager (http://localhost:8000)  
      <img src="https://i.imgur.com/dvxrTfE.png" width="750">  
    - import client project (only once)  
      <img src="https://i.imgur.com/N5LudWT.png" width="750">
    - project dashboard  
      <img src="https://i.imgur.com/WymS5gM.png" width="750">
    - navigate to `Task` tab and click `serve` function then click `Run task` button
      <img src="https://i.imgur.com/jC9VkmZ.png" width="750">
    - wait for task complete and press `Open app` button
      <img src="https://i.imgur.com/tUWgQ0Z.png" width="750">