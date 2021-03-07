# Hackathon Submission Entry form

> __Important__  
> 
> Copy and paste the content of this file into README.md or face automatic __disqualification__  
> All headlines and subheadlines shall be retained if not noted otherwise.  
> Fill in text in each section as instructed and then delete the existing text, including this blockquote.

You can find a very good reference to Github flavoured markdown reference in [this cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet). If you want something a bit more WYSIWYG for editing then could use [StackEdit](https://stackedit.io/app) which provides a more user friendly interface for generating the Markdown code. Those of you who are [VS Code fans](https://code.visualstudio.com/docs/languages/markdown#_markdown-preview) can edit/preview directly in that interface too.

## Team name
No Fears No Bugs

## Category
The best enhancement to the Sitecore Admin (XP) for Content Editors & Marketers

## Description
⟹ Write a clear description of your hackathon entry.  

Our module is called ToyBox, is an enhancement for Sitecore forms. This module contains a set of controls to be used in Sitecore forms to build better forms and bring a better experience to editors with a wider range of custom controls.
The current module solve day to day issues for editors that works with Sitecore Forms and realize they don’t have enough controls and have to build it from scratch.



## Video link
VIDEO folder on root project



## Pre-requisites and Dependencies

make sure Sitecore Forms is available


## Installation instructions
⟹ Write a short clear step-wise instruction on how to install your module.  

Install the Sitecore package file attached to this submission and do a site publish.
Build the solution and publish the projects to the web root folder.
Go to the folder FEE and run npm install to install frontend assets.
Run: npm run watch



### Configuration
You can configure your preffered mail service on App_config/Include folder in you sitecore config:

	<!--  MAIL SERVER
            SMTP server used for sending mails by the Sitecore server
            Is used by MainUtil.SendMail()
            Default value: ""
      -->
    <setting name="MailServer" value="YOUR_SERVICE" />
    <!--  MAIL SERVER USER
            If the SMTP server requires login, enter the user name in this setting
      -->
    <setting name="MailServerUserName" value="YOUR_USERNAME" />
    <!--  MAIL SERVER PASSWORD
            If the SMTP server requires login, enter the password in this setting
      -->
    <setting name="MailServerPassword" value="YOUR_PASSWORD" />
    <!--  MAIL SERVER PORT
            If the SMTP server requires a custom port number, enter the value in this setting.
            The default value is: 25
      -->
    <setting name="MailServerPort" value="YOUR_PORT" />
    <!--  MAIL SERVER SSL
            If the SMTP server requires SSL, set the value to true.
            The default value is: false
    -->
    <setting name="MailServerUseSsl" value="true" />


## Usage instructions
Login to Sitecore and go to Sitecore forms, on the left side you will find ToyBox menu that contains the new custom controls.

