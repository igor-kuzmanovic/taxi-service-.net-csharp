app.config(function ($routeProvider, $locationProvider) {

    $locationProvider.html5Mode({ enabled: true, requireBase: false });

    $routeProvider
        .when("/", {
            templateUrl: "View/Route/Test",
            controller: "TestController",
        })

        .otherwise({ redirectTo: "/" });
});