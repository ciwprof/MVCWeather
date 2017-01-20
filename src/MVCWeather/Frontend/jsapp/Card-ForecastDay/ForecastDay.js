export default class ForecastDay {
    constructor() {
        this.restrict = 'E';
        this.scope = {
            data: '=',
        };
        this.replace = true;
        this.templateUrl = '/ng-partials/jsapp/Card-ForecastDay/forecastDay.html';
        this.controller = ['iconMappings', 'ngDialog', ForecastDayController];
        this.controllerAs = 'fvm';
        this.bindToController = true;
    }
}

class ForecastDayController {
    constructor(iconMappings, ngDialog) {
        this.iconMappings = iconMappings;
        this.ngDialog =  ngDialog;
    }

    openDialog() {
        this.ngDialog.open({
            template: '/ng-partials/jsapp/Card-ForecastDay/forecastDayDialog.html',
            className: 'ngdialog-theme-dark',
            controller: () => { return this; },
            controllerAs: 'fvm'
        });
    }
}