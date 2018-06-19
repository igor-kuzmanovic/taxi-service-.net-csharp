app.factory('CustomerService', ['$http', function ($http) {

    var self = {};
    self.create = create;

    function create(customer) {
        return $http.post("/api/customer", customer);
    }

    return self;

}]);