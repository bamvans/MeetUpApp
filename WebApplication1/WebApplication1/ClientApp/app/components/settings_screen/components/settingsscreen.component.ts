import { Component } from '@angular/core';
import { SettingsScreenService, Category, City } from '../services/settingsscreen.service';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { SelectItem } from 'primeng/components/common/selectitem';
import { Message } from '@angular/compiler/src/i18n/i18n_ast';
import { Router } from '@angular/router';

@Component({
    templateUrl: './settingsscreen.component.html',
    styleUrls: ['./settingsscreen.component.css']
})
export class SettingsScreenComponent implements OnInit{
    
    categories: Category[];
    cities: City[];
    city_Name: SelectItem[];
    category_Name: SelectItem[];
    cityName: any;
    categoryName: any;

    selectedItemCategory: Category[];
    selectedItemCity: City[];

    constructor(private settingsscreenservice: SettingsScreenService, protected router: Router) { }

    ngOnInit() {
        this.settingsscreenservice.getCategories().subscribe(category => this.categories = category);
        this.settingsscreenservice.getCities().subscribe(city => this.cities = city);
        this.city_Name = [];
        this.city_Name.push({ label: 'All Cities', value: null });
        this.city_Name.push({ label: 'Pretoria', value: 'Pretoria' });
        this.city_Name.push({ label: 'Johannesburg', value: 'Johannesburg' });
        this.city_Name.push({ label: 'Cape Town', value: 'Cape Town' });
        this.city_Name.push({ label: 'PE', value: 'PE' });
        this.city_Name.push({ label: 'Hillbrow', value: 'Hillbrow' });
        this.city_Name.push({ label: 'New York', value: 'New York' });
        this.city_Name.push({ label: 'Washington', value: 'Washington' });
        this.city_Name.push({ label: 'Paris', value: 'Paris' });
        this.city_Name.push({ label: 'Bloemfontein', value: 'Bloemfontein' });

        this.category_Name = [];
        this.category_Name.push({ label: 'South Africa', value: 'South Africa' });
        this.category_Name.push({ label: 'America', value: 'America' });
        this.category_Name.push({ label: 'France', value: 'France' });
    }

    onRowSelect(event: any) {
        this.selectedItemCategory = event.data;
        this.selectedItemCity = event.data;
        this.categoryName = this.selectedItemCategory;
        this.cityName = this.selectedItemCity;
        this.settingsscreenservice.createCategories(this.categoryName).subscribe(result => this.categoryName = result);
        this.settingsscreenservice.createCities(this.cityName).subscribe((result => {
            this.cityName = result;
            this.router.navigate(['/group']);
        })
        );
    }
}
