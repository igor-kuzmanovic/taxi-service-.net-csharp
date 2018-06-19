app.controller('LoginController', ['$scope', '$location', 'UserService', function ($scope, $location, UserService) {

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

        if (!self.form.$valid) {
            return;
        }

        UserService.logIn(self.username, self.password)
            .then(
                function (response) {
                    $scope.mainCtrl.loggedIn = true;
                    $scope.mainCtrl.username = self.username;
                    $location.path('/Home');
                },
                function (response) {
                    $http.defaults.headers.common['Authorization'] = null;
                    self.error = response.data.message;
                }
            );
    }
}]);