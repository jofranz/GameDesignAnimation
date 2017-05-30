package com.works.forme

import java.io.File
import java.io.FileInputStream
import java.io.FileOutputStream
import android.R.attr.data



/**
 * Created by normen on 30.05.17.
 */

class Controller constructor(){

    var didbuyItems = booleanArrayOf(false,false)


    //###check if the article already bought###
    fun checkStateof(article: Int) : Boolean?{
         if (article >= didbuyItems.count())
             return null
        else
             return didbuyItems[article]

    }
    //###load Users bought Items ###
    fun saveState(){
        var filename = "UserBoughtState"
        var fos : FileOutputStream = FileOutputStream(filename)
        for (item in didbuyItems)
            fos.write(if (item) 1 else 0)
        fos.close()
    }
    //###load Users bought Items ###
    fun load( ){
        var file  = File("UserBoughtState")
        var fileinput = FileInputStream(file)
        var filelenght = file.length().toInt()

        var data = ByteArray(filelenght)

        fileinput.read(data)
        for (i in 0..data.count() - 1) {
            if (data[i].toInt() !== 0) {
                didbuyItems[i] = true
                continue
            }
            didbuyItems[i] = false
        }


    }



}