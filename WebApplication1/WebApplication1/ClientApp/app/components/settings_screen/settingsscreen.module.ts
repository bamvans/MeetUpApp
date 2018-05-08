import { NgModule, Inject } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { SettingsScreenService } from './services/settingsscreen.service';
import { SettingsScreenComponent } from './components/settingsscreen.component';
import { DataTableModule } from 'primeng/datatable';



@NgModule({
    declarations: [
        SettingsScreenComponent
    ],
    providers: [
        SettingsScreenService
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        DataTableModule,
        RouterModule.forRoot([
            { path: 'settingsscreen', component: SettingsScreenComponent },
            { path: '', redirectTo: 'settingsscreen', pathMatch: 'full' }
        ])
    ]
})

export class SettingsScreenModule {
}
