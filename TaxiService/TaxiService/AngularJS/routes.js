app.config(function ($routeProvider, $locationProvider) {

    $locationProvider.html5Mode({ enabled: true, requireBase: false });

    $routeProvider

        .when("/", {
            templateUrl: "View/Main/Registration",
            controller: "RegistrationController",
            controllerAs: "ctrl"
        })

        .when("/Login", {
            templateUrl: "View/Main/Login",
            controller: "LoginController",
            controllerAs: "ctrl"
        })

        .when("/Home", {
            templateUrl: "View/Main/Home",
            controller: "HomeController",
            controllerAs: "ctrl"
        })

        .otherwise({ redirectTo: "/" });

});