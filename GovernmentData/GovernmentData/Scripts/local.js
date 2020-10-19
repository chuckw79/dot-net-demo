angularApp.controller("DataController", function ($scope, $http) {
    $http.get("/api/AwardRecipients")
        .then(function (res) {
            console.log(res);
            $scope.AwardRecipients = res.data;
        });
});