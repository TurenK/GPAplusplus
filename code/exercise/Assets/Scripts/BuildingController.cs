
using UnityEngine;
using System.Collections;

public class BuildingController : MonoBehaviour {

	public GameObject [] createSoldier;
	public GameObject upLevelMoney;
	public GameObject upLevelWood;

	private ArrayList barracks;	//	所有兵营

	void Update () {
		if (Global.factoryCount == 0) {
			upLevelMoney.SetActive (false);
			upLevelWood.SetActive (false);
		} else {
			upLevelMoney.SetActive (true);
			upLevelWood.SetActive (true);
		}
	}

	//	添加兵营
	public void AddBarrack (Barrack b) {
		barracks.Add (b);
		//	如果是第一次添加, 显示创建士兵的按钮
		if (barracks.Count == 1) {
            for(int C =0;C<createSoldier.Length;C++ )
            {
                createSoldier[C].SetActive (true);
            }
		}
	}

	//	设置主兵营
	public void SetMainBarrack (Barrack b) {
		//	移除兵营
		barracks.Remove (b);
		//	重新将兵营插入到数组首位
		barracks.Insert (0, b);
	}

	//	移除兵营
	public void RemoveBarrack (Barrack b) {
		barracks.Remove (b);
		if (barracks.Count == 0) {
			//	不显示生产士兵按钮
            for(int c = 0; c < createSoldier.Length; c++)
            {
			    createSoldier[c].SetActive (false);
            }
		}
	}

	//	生产炮灰
	public void CreateSoldier0 () {

		(barracks [0] as Barrack).CreateSoldier (0);
	}

    //	生产初级士兵
    public void CreateSoldier1()
    {

        (barracks[0] as Barrack).CreateSoldier(1);
    }
    //	生产二级士兵
    public void CreateSoldier2()
    {

        (barracks[0] as Barrack).CreateSoldier(2);
    }
    //	生产三级士兵
    public void CreateSoldier3()
    {

        (barracks[0] as Barrack).CreateSoldier(3);
    }
    //	生产终极兵器
    public void CreateSoldier4()
    {

        (barracks[0] as Barrack).CreateSoldier(4);
    }

    public ArrayList buildings;	//	当前地图中所有建筑物

	void Awake () {
		//	初始化成员变量
		buildings = new ArrayList ();
		barracks = new ArrayList ();
	}

	//	检查格子是否有效
	public bool InspectGrid (Vector3 pos) {
		bool tempB = true;
		//	遍历所有建筑物
		foreach (Building b in buildings) {
			//	遍历建筑物中所有格子
			foreach (Grid g in b.grids) {
				//	检测格子的位置是否重复
				if (pos == g.pos) {
					//	格子无效
					tempB = false;
					break;
				}
			}
			//	如果已经无效则跳出循环
			if (!tempB) {
				break;
			}
		}
		return tempB;
	}
}
