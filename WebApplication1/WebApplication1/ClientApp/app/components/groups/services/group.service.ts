import { Component } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Router } from '@angular/router';
import { DomSanitizer } from '@angular/platform-browser';
import { Injectable } from '@angular/core'
import 'rxjs/add/operator/map';  
import { Category, City } from '../../settings_screen/services/settingsscreen.service';

@Injectable()
export class GroupService {

    constructor(private http: Http, private router: Router, private sanitizer: DomSanitizer) {
    }

    //get for groups
    public getGroups() {
        return this.http.get("http://localhost:60440/api/group")
            .map((response: Response) => <Group[]>response.json());
    }

    //create for Groups
    public createGroups(gg: Group) {
        return this.http.post("http://localhost:60440/api/group/create", gg)
            .map(x => <Group>x.json());
    }

    public getbyCity(city: string) {
        return this.http.get("http://localhost:60440/api/group" + city)
            .map((response: Response) => response.json());
    }
}


export interface Group {
    id: number;
    name: string;
    category?: Category;
    city?: City;
}
