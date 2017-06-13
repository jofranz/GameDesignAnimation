package com.works.forme

import android.content.Context

/**
 * Created by normen on 30.05.17.
 */
class Model
{
    var firstname = ""
    var secondname = ""
    var location = ""

    private constructor(context: Context)
    {
        firstname = "Duncan"
        secondname = "Dumb"
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
