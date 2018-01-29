﻿import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'

@Component({
    template: ''
})

export class LogoutComponent implements OnInit{

    constructor(private _router: Router) { }

    ngOnInit() 
    {
        localStorage.removeItem('currentCustomer')
        this._router.navigate(['Home']);
    }
}

