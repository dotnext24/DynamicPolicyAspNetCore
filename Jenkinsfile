#!/usr/bin/env groovy
pipeline {
    agent any
    environment {
        
    }
    stages {
        stage ('Clean workspace') {
  steps {
    cleanWs()
  }
}
       stage('Restore packages') {
  steps {
    bat "dotnet restore ${workspace}\\<path-to-solution>\\<solution-project-name>.sln"
  }
}
        stage('Clean') {
  steps {
    bat "msbuild.exe ${workspace}\\<path-to-solution\\<solution-project-name>.sln" /nologo /nr:false /p:platform=\"x64\" /p:configuration=\"release\" /t:clean"
  }
}

stage('Build') {
 steps {
  bat "msbuild.exe ${workspace}\\<path-to-solution>\\<solution-name>.sln /nologo /nr:false  /p:platform=\"x64\" /p:configuration=\"release\" /p:PackageCertificateKeyFile=<path-to-certificate-file>.pfx /t:clean;restore;rebuild"
 }
}





    }
}
