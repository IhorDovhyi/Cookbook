import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { RecipeListComponent } from './recipe-list.component';
import { RecipeChildListComponent } from './recipe-child-list.component';
import { RecipeFormComponent } from './recipe-form.component';
import { RecipeCreateComponent } from './recipe-create.component';
import { RecipeCreateChildComponent } from './recipe-create-child.component';
import { RecipeEditComponent } from './recipe-edit.component';
import { RecipeHistoriPage } from './recipe-history.component';
import { NotFoundComponent } from './not-found.component';
import { DescriptionPageComponent } from './description-page.component';
import { AlphabeticalPipe } from './alphabetical.pipe';

import { DataService } from './data.service';


const appRoutes: Routes = [
    { path: '', component: RecipeListComponent },
    { path: 'create', component: RecipeCreateComponent },
    { path: 'create/:id', component: RecipeCreateChildComponent },
    { path: 'edit/:id', component: RecipeEditComponent },
    { path: 'history/:id', component: RecipeHistoriPage },
    { path: 'description/:id', component: DescriptionPageComponent },
    { path: '**', component: NotFoundComponent }
];

@NgModule(
    {
    imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
    declarations: [AppComponent, RecipeListComponent, RecipeChildListComponent, RecipeCreateComponent,
                   RecipeCreateChildComponent, RecipeEditComponent, DescriptionPageComponent,
                   RecipeFormComponent, RecipeHistoriPage, NotFoundComponent, AlphabeticalPipe],
    providers: [DataService],
    bootstrap: [AppComponent]
})
export class AppModule { }