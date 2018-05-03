import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Router } from '@angular/router';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
    templateUrl: './settingsscreen.component.html',
    styleUrls: ['./settingsscreen.component.css']
})
export class SettingsScreenService {

    constructor(private http: Http, private router: Router, private sanitizer: DomSanitizer) {
    }
}

export interface Category {
    id: number;
    name: string;
    description: string;
}

export interface City {
    id: number;
    name: string;
}

export interface Group {
    id: number;
    name: string;
    category?: Category;
    city?: City;
}