app.controller('MainController', ['$scope', '$location', 'UserService', function ($scope, $location, UserService) {

    var self = this;
    self.logOut = logOut;

    function logOut() {
        delete self.username;
        $location.path('/');
    }

}]);