import { Component, OnInit } from '@angular/core';
import { GroupService } from '../services/group.service';
import { Router } from '@angular/router';
import { SettingsScreenService } from '../../settings_screen/services/settingsscreen.service';

@Component({
    templateUrl: './group.component.html',
    styleUrls: ['./group.component.css']
})
export class GroupComponent implements OnInit{

    constructor(private groupsservice: GroupService, protected router: Router, private settingsscreenservice: SettingsScreenService) { }


    ngOnInit() {

        
    }
}
