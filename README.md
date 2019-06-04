# CommonUI
Example for Asp.net Core Web

# POC To-do List
* Project 
    - Completed
        - May
            - ✔ ~~[DEV] setup recommand VS code extension list in workspace setting~~
            - ✔ ~~[DEV] setup project folder structure~~ (TBC)
* Client
    - Completed
        - May
            - ✔ ~~[DEV] Setup Code format setting (TSLint/ESlint)~~
        - Jun.
            - ✔ ~~[[DEV] Main page layout (Element UI)~~  (4 Jun.)
            - ✔ ~~[DEV] Vue Router [history mode](https://router.vuejs.org/guide/essentials/history-mode.html#example-server-configurations)~~ (4 Jun.)
            - ✔ ~~[[DEV] Publish to Server/wwwroot folder~~ (4 Jun.)
            - ✔ ~~[PRD] Choose UI framework~~ (4 Jun.)
    - Uncompleted            
        - [DEV] Vue lazy loading (TBC: prefetch issue)
        - [DEV] Proxy local api request to different port (8080->5000)
        - [DEV] Element UI Color Theme (Element UI) 
        - [DEV] Vuex adoption
        - [DEV] Vue Router: Authentication & Authorization
        - [DEV] API communication encapsulation

* Server
    - Completed
        - May
            - ✔ ~~[DEV] Windows Authentication (IIS Express / Self-Contained)~~  
            - ✔ ~~[DEV] Integrate Client publish with command with`dotnet publish`~~
            - ✔ ~~[DEV] Integrate Client publish with command with `dotnet build`~~
    - Uncompleted            
        - [DEV] Authorization: set current user role 
        - [DEV] Host by IIS  
        - [DEV] Host by Windows Service  
        - [DEV] Host by Docker  
        - [PRD] Windows Authentication when host by IIS  
        - [PRD] Windows Authentication when host by Windows Service  
        - [PRD] Windows Authentication when host by Docker

# Known Issues
* Integrated development mode (press `F5` in VS code) makes VS code slow response and random ouccrs proxy error
    - [recommand] serve client and server into different terminal


# Refrenece Articles
https://alligator.io/vuejs/typescript-class-components/
https://github.com/SimonZhangITer/vue-typescript-dpapp-demo
https://juejin.im/post/5c173a84f265da610e7ffe44
https://taylorchen709.github.io/vue-admin/#/table
https://github.com/PanJiaChen/vue-element-admin/tree/master/src