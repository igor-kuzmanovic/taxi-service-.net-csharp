app.factory('UserService', ['$http', function ($http) {

    var self = {};

    self.createCustomer = function(customer) {
        return $http.post("/api/customer", customer);
    }

    return self;

}]);