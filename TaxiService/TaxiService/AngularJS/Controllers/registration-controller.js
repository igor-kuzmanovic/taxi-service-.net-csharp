app.controller('RegistrationController', ['$scope', '$location', 'CustomerService', function ($scope, $location, CustomerService) {

    var self = this;
    self.submit = submit;

    init();

    function init() {
        if ($scope.mainCtrl.loggedIn) {
            $location.path('/Home');
        }
    }

    function submit() {
        delete self.error;
        self.form.username.$setDirty();
        self.form.password.$setDirty();
        self.form.email.$setDirty();

        if (!self.form.$valid) {
            return;
        }

        var user = {
            username: self.username,
            password: self.password,
            email: self.email
        }

        CustomerService.create(user)
            .then(
                function (response) {
                    $location.path('/Login');
                },
                function (response) {
                    self.error = response.data.message;
                }
            );
    }

}]);