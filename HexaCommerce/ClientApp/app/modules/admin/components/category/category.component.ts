import { Component, OnInit, ViewChild } from '@angular/core';
import { CategoryModel } from './category.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RepositoryService } from '../../../../shared/repository.service';
import { ConfirmationService } from 'primeng/api';

@Component({
    selector: 'Category',
    templateUrl: './category.component.html',
    styleUrls: ['./category.component.css'],
    providers: [RepositoryService, ConfirmationService]
})
export class CategoryComponent implements OnInit {

    categories: CategoryModel[];
    categoryFrm: FormGroup;

    constructor(private _repositoryService: RepositoryService, private fb: FormBuilder, private _confirmationService: ConfirmationService) { }

    ngOnInit() {

        this.categoryFrm = this.fb.group({
            Name: [''],
            Description: ['', Validators.required],
            ParentCategoryId: [''],
            IncludeInNavigation: true,
            Active: true,
            Deleted: false,
            DisplayOrder: ['']
        });

        this._repositoryService.get("/admin/api/category/").subscribe(data => {
            this.categories = data
        }, error => {
            if (error) {
                alert("Error")
            }
        });
    }

    confirmDelete(id: number) {
        this._confirmationService.confirm({
            message: 'Are you sure that you want to delete this category?',
            accept: () => {
                //Actual logic to perform a confirmation
                this._repositoryService.delete(id, "/admin/api/category/").subscribe(data => {
                    this.ngOnInit();
                }, error => {
                    if (error) {
                        alert("Error")
                    }
                });
            }
        });
    }
}
