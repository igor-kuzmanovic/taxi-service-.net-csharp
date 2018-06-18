app.controller('HomeController', ['$scope', '$location', function ($scope, $location) {

    var self = this;
    self.username = $scope.mainCtrl.username;

    init();

    function init() {
        if (!$scope.mainCtrl.username) {
            $location.path('/Login');
        }
    }

}]);