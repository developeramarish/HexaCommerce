import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
    private data: any;
    UserName: string = '';

    constructor() {

    }

    ngOnInit() {

        const userJson = localStorage.getItem('registeredCustomer');
        this.UserName = userJson !== null ? JSON.parse(userJson).username : null;
    }
}
