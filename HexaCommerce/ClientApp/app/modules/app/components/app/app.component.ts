import { Component } from '@angular/core';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    private data: any;
    ifCustomerLoggedIn: boolean;
    ifAdminCustomer: boolean;

    constructor() {
    };

    ngOnInit() {
        const userJson = localStorage.getItem('currentCustomer');
        this.ifCustomerLoggedIn = userJson !== null;
        this.ifAdminCustomer = userJson !== null ? JSON.parse(userJson).isAdmin : null;
    }
}
