import { Usuario } from "./usuario.model";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class UsuarioService {
  formData: Usuario;
  list: Usuario[];
  readonly rootURL = "https://localhost:44333/api";
  constructor(private http: HttpClient) {}

  postUsuario(formData: Usuario) {
    return this.http.post(this.rootURL + "/Usuarios", formData);
  }

  refreshList() {
    this.http
      .get(this.rootURL + "/Usuarios")
      .toPromise()
      .then(res => (this.list = res as Usuario[]));
  }

  putUsuario(formData: Usuario) {
    return this.http.put(this.rootURL + "/Usuarios/" + formData.id, formData);
  }

  deleteUsuario(id: number) {
    return this.http.delete(this.rootURL + "/Usuarios/" + id);
  }
}
