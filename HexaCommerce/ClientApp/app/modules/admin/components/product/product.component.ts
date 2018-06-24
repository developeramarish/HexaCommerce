import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductModel } from './product.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RepositoryService } from '../../../../shared/repository.service';
import { ConfirmationService } from 'primeng/api';
import { Message } from 'primeng/api';

@Component({
    selector: 'products',
    templateUrl: './product.component.html',
    styleUrls: ['./product.component.css'],
    providers: [RepositoryService, ConfirmationService]
})
export class ProductComponent implements OnInit {

    products: ProductModel[];
    productFrm: FormGroup;
    msgs: Message[] = [];

    constructor(private _repositoryService: RepositoryService, private fb: FormBuilder, private _confirmationService: ConfirmationService) { }

    ngOnInit() {

        this.productFrm = this.fb.group({
            Id: 0,
            Name: ['', Validators.required],
            ShortDescription: ['', Validators.required],
            FullDescription: '',
            ShowOnHomePage: true,
            Price: [0, Validators.required],
            Deleted: false,
            Published: true,
            DisplayOrder: 0
        });

        this._repositoryService.get("/admin/api/product/").subscribe(data => {
            this.products = data
        }, error => {
            if (error) {
                this.msgs = [];
                this.msgs.push({ severity: 'error', summary: 'Error', detail: 'Error in loading products...' });
            }
        });
    }

    confirmDelete(id: number) {
        this._confirmationService.confirm({
            message: 'Are you sure that you want to delete this product?',
            accept: () => {
                //Actual logic to perform a confirmation
                this._repositoryService.delete(id, "/admin/api/product/").subscribe(data => {
                    this.ngOnInit();
                }, error => {
                    if (error) {
                        this.msgs = [];
                        this.msgs.push({ severity: 'error', summary: 'Error', detail: 'Error in deleting product...' });
                    }
                });
            }
        });
    }
}
