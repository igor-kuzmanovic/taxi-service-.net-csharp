app.controller('LoginController', ['$scope', '$location', 'UserService', function ($scope, $location, UserService) {

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

        $scope.mainCtrl.username = self.username

        $location.path('/Home');
    }
}]);