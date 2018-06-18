app.controller('RegistrationController', ['$scope', '$location', 'UserService', function ($scope, $location, UserService) {

    var self = this;
    self.submit = submit;

    init();

    function init() {
        if ($scope.mainCtrl.username) {
            $location.path('/Home');
        }
    }

    function submit() {
        if (!self.form.$valid) {
            return;
        }

        var user = {
            username: self.username,
            password: self.password
        }

        UserService.createCustomer(user)
            .then(function (data) {
                alert(data);
            }, function (data) {
                alert(data);
            });
    }

}]);