var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
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
const appRoutes = [
    { path: '', component: RecipeListComponent },
    { path: 'create', component: RecipeCreateComponent },
    { path: 'create/:id', component: RecipeCreateChildComponent },
    { path: 'edit/:id', component: RecipeEditComponent },
    { path: 'history/:id', component: RecipeHistoriPage },
    { path: 'description/:id', component: DescriptionPageComponent },
    { path: '**', component: NotFoundComponent }
];
let AppModule = class AppModule {
};
AppModule = __decorate([
    NgModule({
        imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
        declarations: [AppComponent, RecipeListComponent, RecipeChildListComponent, RecipeCreateComponent,
            RecipeCreateChildComponent, RecipeEditComponent, DescriptionPageComponent,
            RecipeFormComponent, RecipeHistoriPage, NotFoundComponent, AlphabeticalPipe],
        providers: [DataService],
        bootstrap: [AppComponent]
    })
], AppModule);
export { AppModule };
//# sourceMappingURL=app.module.js.map