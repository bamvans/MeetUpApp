import { Component, OnInit, group } from '@angular/core';
import { GroupService, Group } from '../services/group.service';
import { Router, ParamMap, ActivatedRoute } from '@angular/router';
import { SettingsScreenService, Category, City } from '../../settings_screen/services/settingsscreen.service';
import { SelectItem } from 'primeng/components/common/selectitem';

@Component({
    templateUrl: './group.component.html',
    styleUrls: ['./group.component.css']
})
export class GroupComponent implements OnInit {

    categories: Category;
    cities: City;

    group: Group;

    categoryId: string;
    cityId: string;

    route: ActivatedRoute;

    categoriess: Category[];
    citiess: City[];
    city_Name: SelectItem[];
    category_Name: SelectItem[];
    cityName: any;
    categoryName: any;

    selectedItemCategory: Category[];
    selectedItemCity: City[];

    constructor(private groupsservice: GroupService, protected router: Router, private settingsscreenservice: SettingsScreenService) { }


    ngOnInit() {
        this.route.paramMap
            .subscribe((params: ParamMap) => {
                let id = params.get('id');
                let cid = params.get('cid');
                this.categoryId = id;
                this.cityId = cid;
                this.settingsscreenservice.getByIdCategories(this.categoryId).subscribe(result => this.categories = result);
                this.settingsscreenservice.getByIdCities(this.cityId).subscribe(result => this.cities = result);
                if (this.cities.name=this.group.city) {
                    this.groupsservice.getbyCity(this.cities.name).subscribe(result => this.group = result);
                }
            });

        this.settingsscreenservice.getCategories().subscribe(category => this.categoriess = category);
        this.settingsscreenservice.getCities().subscribe(city => this.citiess = city);
    }

    onRowSelect(event: any) {
        this.selectedItemCategory = event.data;
        this.selectedItemCity = event.data;
        this.categoryName = this.selectedItemCategory;
        this.cityName = this.selectedItemCity;
        this.settingsscreenservice.createCategories(this.categoryName).subscribe(result => this.categoryName = result);
        this.settingsscreenservice.createCities(this.cityName).subscribe((result => {
            this.cityName = result;
        })
        );
    }
}
