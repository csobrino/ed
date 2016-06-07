package com.mycompany.acategoria;

import android.app.DownloadManager;
import android.database.sqlite.SQLiteDatabase;

import java.util.List;

/**
 * Created by mati on 30/05/16.
 */
public class Categoria {

    public long id;
    public String nombre;

    public Categoria(long id, String nombre) {

        this.id=id;
        this.nombre=nombre;
    }

    public String toString(){

        return String.format("[%d] %s", id, nombre);

    }




}
