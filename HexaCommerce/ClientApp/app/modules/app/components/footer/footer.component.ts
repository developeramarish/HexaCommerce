import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'footer',
    templateUrl: './footer.component.html',
    styleUrls: ['./footer.component.css', '../app/app.component.css']
})
export class FooterComponent implements OnInit {
    private data: any;
    ifCustomerLoggedIn: boolean;
    ifAdminCustomer: boolean;

    constructor() { };

    ngOnInit() {
        const userJson = localStorage.getItem('currentCustomer');
        this.ifCustomerLoggedIn = userJson !== null;
        this.ifAdminCustomer = userJson !== null ? JSON.parse(userJson).isAdmin : null;
    }
}

