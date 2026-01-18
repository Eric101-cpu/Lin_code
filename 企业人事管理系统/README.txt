

2025/12/8  修复SQL链接

2025/12/20 完成并调试成功部门管理的“增、删、改”

 
 
 问题1：为什么在DeptForm.cs中调用DeptSearchForm时，传入的参数是this？
 【DeptForm.cs】
 private void toolStripButton4_Click(object sender, EventArgs e)  //查找
        {
            this.Hide();
            DeptSearchForm deptSearchForm = new DeptSearchForm(this); 
            deptSearchForm.Show();
        }
this是把当前主窗体对象传给搜索窗体（DeptSearchForm）的构造函数，核心作用有两个：

	1.	建立窗体间的关联
DeptSearchForm的构造函数设计时需要接收一个DeptForm类型的参数（就是你之前看到的搜索窗体代码里的public DeptSearchForm(DeptForm deptForm)），
this在这里代表当前的主窗体实例，把它传进去后，搜索窗体就能拿到主窗体的对象引用，
后续可以直接调用主窗体的方法（比如刷新表格的SetDeptGrid、重新加载数据的DeptForm_Load）。

	2.	实现数据交互与界面联动
比如你在搜索窗体里完成查询后，需要把结果回显到主窗体的DataGridView表格中，搜索窗体就可以通过传入的这个主窗体对象，
直接操作主窗体的控件或调用其方法，不用再写复杂的跨窗体传值逻辑，让两个窗体的交互更直接。

简单说，this就是给搜索窗体递了一张“主窗体的身份证”，让搜索窗体认识主窗体，能和主窗体沟通、操作主窗体的内容。


问题2：【name ?? (object)DBNull.Value;】  
空值处逻辑             
如果用户输入的name是NULL，直接传入null会抛出异常。

??：是C#的空合并运算，“如果name值为NULL，就用DBNull.Value替代
    （DBNull.Value是数据库认可的空值类型）