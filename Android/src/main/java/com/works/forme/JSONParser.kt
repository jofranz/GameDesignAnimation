package com.works.forme

import android.content.Context
import android.telephony.cdma.CdmaCellLocation
import org.json.JSONArray
import org.json.JSONException
import org.json.JSONObject
import java.lang.Exception


class JSONParser constructor(context: Context){

    var context : Context? = null

    init {
        this.context = context
    }

    //parse the data from the Json response from facebook
    fun parseJSON(json: JSONObject){
        var location : String? = null
        val name : String?  = json.getString("name")
        var hometown = null
        try {
            var hometown : JSONArray? = json.getJSONArray("hometown")
        }catch (e: JSONException){
        }
        if (hometown != null){
            location = json.getString("location")
        }
        writeData(name,location)

    }
    //write the data from JSON into the model
    fun writeData(name: String?,location: String?){
        var model = Model.getInstance(context!!)
        if (name != null){
           var jsonStr = name

            var tmp = jsonStr.split(" ")
            model.firstname = tmp[0]
            var name = ""
            for (i in 1..tmp.count()){
                name += name + " "
            }
            model.secondname = name
            if (location != null ){
                model.location = location
            }
        }

    }

}
/**
 * Created by normen on 31.05.17.
 */
