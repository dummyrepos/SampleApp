pipeline {
    agent any
    environment {
 	PATH = "${env.PATH}:/var/lib/jenkins/.dotnet/tools"
    }
    stages {
        stage('git'){
   	   steps {
		git branch: 'main', url: 'https://github.com/dummyrepos/SampleApp.git'
	   }
	}
        stage('SonarQube analysis') {
            steps {
                withSonarQubeEnv('sonarcloud') {
		    sh 'export PATH="$PATH:/var/lib/jenkins/.dotnet/tools"'
                    sh '/usr/bin/dotnet sonarscanner begin /k:"april24_sampleapp" /o:"april24" /d:sonar.login="d51b77568f7a262527616a45a5c89ccde1323a29" /d:sonar.host.url="https://sonarcloud.io"'
                    sh '/usr/bin/dotnet build SampleApp.sln'
                    sh '/usr/bin/dotnet test SampleApp.sln'
                    sh '/usr/bin/dotnet sonarscanner end /d:sonar.login="d51b77568f7a262527616a45a5c89ccde1323a29"'
                }
            }
        }
	stage("Quality Gate") {
		steps {
			timeout(time: 1, unit: 'HOURS') {
				// Parameter indicates whether to set pipeline to UNSTABLE if Quality Gate fails
				// true = set pipeline to UNSTABLE, false = don't
				waitForQualityGate abortPipeline: true
			}
		}
	}
    }
}
