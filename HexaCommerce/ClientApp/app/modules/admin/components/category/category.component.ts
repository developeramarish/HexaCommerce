import { Component, OnInit, ViewChild } from '@angular/core';
import { CategoryModel } from './category.model';
import { CategoryService } from './category.service';
import { BsModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
    selector: 'Category',
    templateUrl: './category.component.html',
    providers: [CategoryService]
})
export class CategoryComponent implements OnInit {

    @ViewChild('modal') modal: BsModalComponent;
    Categories: CategoryModel[];
    categoryFrm: FormGroup;

    constructor(private _categoryService: CategoryService, private fb: FormBuilder) { }

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

        this._categoryService.getAllCategories().subscribe(data => {
            this.Categories = data
        }, error => {
            if (error) {
                alert("Error")
            }
        });
    }
}
