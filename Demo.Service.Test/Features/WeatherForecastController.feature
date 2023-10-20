Feature: Testing a REST API with a Local Server
    In order to verify the API behavior
    As a developer
    I want to test the API with a local server

    Background:
        Given a local REST server is started

    Scenario: Verify API behavior
        When I make a GET request to the API endpoint "/WeatherForecast"
        Then the response status code should be 200
        And the response should contain expected data