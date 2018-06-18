app.service('UserService', ['$http', function ($http) {

    var self = this;
    self.createCustomer = createCustomer

    function createCustomer(customer) {
        var promise = $http({
            method: 'POST',
            url: "/api/customer",
            data: customer
        }).then(function (response) {
            return response.data.CustomerId;
        }, function (response) {
            return response.data.Message;
        });
        return promise;
    }

}]);