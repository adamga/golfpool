provider "aws" {
  region = "us-east-1"
}

resource "aws_elastic_beanstalk_application" "golfpool_app" {
  name = "golfpool-app"
}

resource "aws_elastic_beanstalk_environment" "golfpool_env" {
  name                = "golfpool-env"
  application         = aws_elastic_beanstalk_application.golfpool_app.name
  solution_stack_name = "64bit Amazon Linux 2 v3.4.6 running .NET Core"
}