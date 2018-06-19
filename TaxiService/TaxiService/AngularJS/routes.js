app.config(function ($routeProvider, $locationProvider) {

    $routeProvider

        .when("/", {
            templateUrl: "View/Registration",
            controller: "RegistrationController",
            controllerAs: "ctrl"
        })

        .when("/Login", {
            templateUrl: "View/Login",
            controller: "LoginController",
            controllerAs: "ctrl"
        })

        .when("/Home", {
            templateUrl: "View/Home",
            controller: "HomeController",
            controllerAs: "ctrl"
        })

        .otherwise({ redirectTo: "/Home" });

    $locationProvider.html5Mode(true);

});