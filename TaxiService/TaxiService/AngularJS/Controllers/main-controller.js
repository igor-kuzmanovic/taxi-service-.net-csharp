app.controller('MainController', ['$scope', '$location', 'UserService', function ($scope, $location, UserService) {

    var self = this;
    self.logOut = logOut;

    function logOut() {      
        UserService.logOut()
            .then(
                function (response) {
                    delete self.loggedIn;
                    delete self.username;
                    $http.defaults.headers.common['Authorization'] = null;
                    $location.path('/Login');
                },
                function (response) {
                    self.error = response.data.message;
                }
            );
    }

}]);