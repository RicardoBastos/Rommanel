import { UsuarioService } from "./shared/usuario.service";
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { CommonModule } from "@angular/common";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { ToastrModule } from "ngx-toastr";

import { appRoutingModule } from "./app.routing";
import { AppComponent } from "./app.component";
import { HomeComponent } from "./home/home.component";
import { UsuariosComponent } from "./usuarios/usuarios.component";
import { UsuarioComponent } from "./usuarios/usuario/usuario.component";
import { UsuarioListComponent } from "./usuarios/usuario-list/usuario-list.component";

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    UsuariosComponent,
    UsuarioComponent,
    UsuarioListComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    appRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [UsuarioService],
  bootstrap: [AppComponent]
})
export class AppModule {}
