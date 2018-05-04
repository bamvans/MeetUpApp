import { Component } from '@angular/core';
import { SettingsScreenService, Category } from '../services/settingsscreen.service';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
    templateUrl: './settingsscreen.component.html',
    styleUrls: ['./settingsscreen.component.css']
})
export class SettingsScreenComponent implements OnInit{

    categories: Category[];

    constructor(private settings_screenService: SettingsScreenService) {

    }

    ngOnInit() {
        //calling a method  
        this.LoadCategories();
    }

    //Created a method to call getCategories method in our SettingsScreen Service.  
    LoadCategories() {
        this.settings_screenService.getCategories().subscribe((x) => this.categories = x);
    }  
}
