package com.works.forme

import android.content.Context

/**
 * Created by normen on 30.05.17.
 */
class Model
{
    private var firstname = ""
    private  var secondname = ""
    private var location = ""
    private  var age = 26
    private constructor(context: Context)
    {
        firstname = "Duncan"
        secondname = "Dumb"
        age = 26
        location = "Undertown"
    }

    companion object
    {
        private var instance: Model? = null
        fun getInstance(context: Context): Model
        {
            if(instance == null)
            {
                instance = Model(context)
            }

            return instance!!
        }
    }
}
