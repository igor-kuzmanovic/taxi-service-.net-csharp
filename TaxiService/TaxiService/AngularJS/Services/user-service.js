app.factory('UserService', ['$http', function ($http) {

    var self = {};
    //self.logIn = logIn;
    //self.logOut = logOut;

    self.logIn = function(username, password) {
        $http.defaults.headers.common['Authorization'] = 'Basic ' + btoa(username + ':' + password);
        return $http.post("/api/user");
    }

    self.logOut = function() {
        return $http.delete("/api/user");
    }

    return self;

}]);