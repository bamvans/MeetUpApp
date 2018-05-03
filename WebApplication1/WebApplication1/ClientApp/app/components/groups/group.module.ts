import { NgModule, Inject } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { GroupService } from './services/group.service';
import { GroupComponent } from './components/group.component';



@NgModule({
    declarations: [
        GroupComponent
    ],
    providers: [
        GroupService
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,

        RouterModule.forRoot([
            { path: 'group', component: GroupComponent },
            { path: '', redirectTo: 'group', pathMatch: 'full' }
        ])
    ]
})

export class GroupModule {
}

