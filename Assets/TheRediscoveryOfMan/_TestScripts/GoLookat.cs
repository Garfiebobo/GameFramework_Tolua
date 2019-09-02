using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoLookat : MonoBehaviour
{

    public GameObject sp;
    private float rotateSpeed = 100;
    private float speedratio = 1;
    // Update is called once per frame
    void Update()
    {
        Lookat(sp);
    }
    void Lookat(GameObject sp)
    {
        Vector3 targetDir = sp.transform.position - transform.position;     //目標向量
        float angle = Vector3.Angle(this.transform.forward, targetDir);      //求出两向量之间的夹角 
        float minAngle = Mathf.Min(angle, rotateSpeed * Time.deltaTime* speedratio);   //返回最小值  用來判斷 旋轉朝向是否到达
        transform.Rotate(Vector3.Cross(this.transform.forward, targetDir.normalized), minAngle);   //进行插值旋转     Vector3.Cross(this.transform.forward, targetDir.normalized)  这一步可以优化成别的曲线类的方法
    }
}
